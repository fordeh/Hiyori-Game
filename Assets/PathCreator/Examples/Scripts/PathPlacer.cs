using PathCreation;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        public GameObject hoopPrefab;
        public GameObject holder;
        public float spacing;
        const float minSpacing = .1f;
        public Material[] glow_materials;
        public Material prefabMaterial;
        public int indexNumber;
        GameObject prefabClone;
        





        void Awake()
        {

        }


        void Generate () {
            if (pathCreator != null && hoopPrefab != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;


                

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);


                    indexNumber = Random.Range(0, glow_materials.Length); // randomly pick #

                    prefabMaterial = glow_materials[indexNumber]; // material = random # of material list
                    
                    prefabClone = Instantiate (hoopPrefab, point, rot, holder.transform); // clone hoop prefab
                

            


                    dst += spacing; // distance from each other = spacing
                    Renderer clone_renderer = prefabClone.GetComponent<Renderer>(); // access renderer
                    clone_renderer.material = prefabMaterial; // material of clone prehab = random material

                  


                }

                
            }
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate();
            }
        }






        // change materials randomly --- rainbow gets highest points
    }
}