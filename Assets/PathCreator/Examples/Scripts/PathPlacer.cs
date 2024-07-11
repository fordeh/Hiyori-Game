using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        public GameObject hoop_prefab;
        public GameObject holder;
        public float spacing;
        const float minSpacing = .1f;
        public Material[] glow_materials;
        public Material prefab_material;
        public int index;
        GameObject prefab_clone;


        void Generate () {
            if (pathCreator != null && hoop_prefab != null && holder != null) {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;

                while (dst < path.length) {
                    Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);

                    index = Random.Range(0, glow_materials.Length);

                    prefab_material = glow_materials[index];


                    prefab_clone = Instantiate (hoop_prefab, point, rot, holder.transform);
                    dst += spacing;
                    Renderer clone_renderer = prefab_clone.GetComponent<Renderer>();
                    clone_renderer.material = prefab_material;

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
                Generate ();
            }
        }

        // change materials randomly --- rainbow gets highest points
    }
}