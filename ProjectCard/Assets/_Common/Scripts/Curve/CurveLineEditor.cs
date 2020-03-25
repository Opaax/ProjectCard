#if UNITY_EDITOR
///-----------------------------------------------------------------
/// Author : 
/// Date : 29/02/2020 16:28
///-----------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Com.PackSoor.ProjectCard.Common.Curve {
    [CustomEditor(typeof(CurveLine))]
    public class CurveLineEditor : Editor {
        private const int linesSteps = 30;
        private const float directionScale = 0.5f;

        private CurveLine curve;
        private Transform handleTransform;
        private Quaternion handleRotation;

        private Vector3[] totalPath;
        private float totalPathLenght;
        private float xSize;

        private bool rendererIsOnChild = false;
        private int indexChild = 0;

        private bool MoreOption = false;
        private bool doNotRotateAroudObject = false;
        private bool rotateAroundSphericObject = false;
        private Object sphericalObject = null;
        private bool isInsideObject = false;

        private void OnSceneGUI()
        {
            curve = target as CurveLine;
            handleTransform = curve.transform;
            handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;

            Vector3 point0 = ShowPoint(0);
            Vector3 point1 = ShowPoint(1);
            Vector3 point2 = ShowPoint(2);
            Vector3 point3 = ShowPoint(3);

            Handles.color = Color.red;
            Handles.DrawLine(point0, point1);
            Handles.DrawLine(point2, point3);

            ShowDirections();
            Handles.DrawBezier(point0, point3, point1, point2, Color.green, null, 2f);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CurveLine curve = target as CurveLine;

            EditorGUILayout.Space();

            rendererIsOnChild = EditorGUILayout.BeginToggleGroup("RendererOnChild", rendererIsOnChild);
            if (rendererIsOnChild)
            {
                indexChild = EditorGUILayout.IntField("indexOfChild",indexChild);
            }
            EditorGUILayout.EndToggleGroup();

            MoreOption = EditorGUILayout.BeginToggleGroup("MoreOption", MoreOption);
            if (MoreOption)
            {
                doNotRotateAroudObject = EditorGUILayout.Toggle("DoNotRotateObject", doNotRotateAroudObject);
                rotateAroundSphericObject = EditorGUILayout.BeginToggleGroup("rotateAroundSphericObject", rotateAroundSphericObject);
                if(rotateAroundSphericObject)
                {
                    sphericalObject = EditorGUILayout.ObjectField("SphericalObject", sphericalObject, typeof(GameObject));

                    GameObject lObject = sphericalObject as GameObject;

                    if(lObject !=null)
                        if (!lObject.GetComponent<MeshRenderer>())
                            EditorGUILayout.HelpBox("the object must have meshRederer", MessageType.Warning);

                    isInsideObject = EditorGUILayout.Toggle("isInsideObject", isInsideObject);
                }
                EditorGUILayout.EndToggleGroup();
            }
            EditorGUILayout.EndToggleGroup();

            if (GUILayout.Button("Generate Collectible Path"))
            {
                if(rendererIsOnChild)
                    xSize = curve.ObjectToInstantiate.transform.GetChild(indexChild).transform.GetComponent<SpriteRenderer>().bounds.size.x;
                else
                    xSize = curve.ObjectToInstantiate.GetComponent<SpriteRenderer>().bounds.size.x;
                int lNumberToSpawn = (int)(totalPathLenght / (curve.Spacing + xSize));
                curve.LastPath = new GameObject[(lNumberToSpawn + 1) * curve.NLinesToSpawn];
                int lTotalObject = -1;

                for (int i = 0; i <= lNumberToSpawn; i++)
                {
                    for (int j = 0; j < curve.NLinesToSpawn; j++)
                    {
                        ++lTotalObject;
                        GameObject lObject = Instantiate(curve.ObjectToInstantiate);
                        float lRatio = (float)i / lNumberToSpawn;
                        Vector3 lPosition = curve.GetPoint(lRatio);                        
                        
                        lObject.transform.position = lPosition;

                        if (!doNotRotateAroudObject)
                        {
                            if (rotateAroundSphericObject)
                            {
                                CastNormal(lObject);
                            }
                            else
                            {
                                float lAngle = Vector3.SignedAngle(lObject.transform.up, curve.GetDirection(lRatio), lObject.transform.forward);
                                lObject.transform.rotation = Quaternion.AngleAxis(lAngle, lObject.transform.forward);
                            }
                        }
                        
                        lObject.transform.SetParent(curve.ObjectToInstantiateParent);

                        lPosition = lPosition + -lObject.transform.right * (curve.Spacing * j);
                        lObject.transform.position = lPosition;

                        curve.LastPath[lTotalObject] = lObject.gameObject;
                    }            
                }
            }

            if (GUILayout.Button("Destruct last path"))
            {
                if (curve != null)
                {
                    if (curve.LastPath.Length == 0) return;

                    for (int i = curve.LastPath.Length - 1; i >= 0; i--)
                    {
                        DestroyImmediate(curve.LastPath[i]);
                    }
                }
                else
                    Debug.LogError(curve.LastPath);
            }

            if (GUILayout.Button("Clear Last Path memories"))
            {
                if (curve != null)
                {
                    if (curve.LastPath.Length == 0) return;

                    curve.LastPath = new GameObject[0];
                }
            }
        }

        private void CastNormal (GameObject fromObject)
        {
            GameObject lSpericalObject = sphericalObject as GameObject;
            Vector3 lDirection = lSpericalObject.transform.GetComponent<MeshRenderer>().bounds.center - fromObject.transform.position;

            if(isInsideObject)
                fromObject.transform.up = lDirection;
            else
                fromObject.transform.up = -lDirection;
        }

        private void ShowDirections()
        {
            totalPathLenght = 0;
            totalPath = new Vector3[linesSteps + 1];
            Vector3 startPoint = curve.GetPoint(0f);
            totalPath[0] = startPoint;
            for (int i = 1; i <= linesSteps; i++)
            {
                float lRatio = i / (float)linesSteps;
                Vector3 endPoint = curve.GetPoint(lRatio);
                startPoint = endPoint;
                totalPath[i] = startPoint;

                Vector3 lDistance = totalPath[i] - totalPath[i - 1];

                totalPathLenght = totalPathLenght + lDistance.magnitude;
            }
        }

        private Vector3 ShowPoint(int index)
        {
            Vector3 point = handleTransform.TransformPoint(curve.PathPoints[index]);

            EditorGUI.BeginChangeCheck();

            point = Handles.DoPositionHandle(point, handleRotation);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(curve, "Move Point");
                EditorUtility.SetDirty(curve);
                curve.PathPoints[index] = handleTransform.InverseTransformPoint(point);
            }

            return point;
        }
    }
}
#endif