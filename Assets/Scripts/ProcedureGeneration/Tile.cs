using UnityEngine;

namespace Game
{
    public class Tile : MonoBehaviour
    {
        public Chunk _creator;
        Transform Parent;
        public GameObject[] Walls;
        public GameObject[] Doors;
        public float TileWidth = 8f;
        float TileWidthDiv2;

        ///////////////////////////////////////////////

        [HideInInspector]
        public GameObject DoorU;
        [HideInInspector]
        public GameObject DoorD;
        [HideInInspector]
        public GameObject DoorR;
        [HideInInspector]
        public GameObject DoorL;

        ///////////////////////////////////////////////

        [HideInInspector]
        public GameObject WallU;
        [HideInInspector]
        public GameObject WallD;
        [HideInInspector]
        public GameObject WallR;
        [HideInInspector]
        public GameObject WallL;




        void Start()
        {
            Parent = gameObject.transform;
            TileWidthDiv2 = TileWidth / 2;

            if (Walls[0] != null) SpawnAndDisactivate(Walls, false);
            if (Doors[0] != null) SpawnAndDisactivate(Doors, true);
            gameObject.GetComponent<RandomizeObject>().RotateDoors();
            _creator.TileSpawned += 1;
        }

        void SpawnAndDisactivate(GameObject[] _object, bool predictor)
        {
            GameObject _instanceU = Instantiate(_object[Random.Range(0, _object.Length)], Parent);
            _instanceU.transform.position = new Vector3(Parent.position.x, Parent.position.y + 0.5f, Parent.position.z + TileWidthDiv2);
            _instanceU.transform.forward = Parent.forward;


            GameObject _instanceD = Instantiate(_object[Random.Range(0, _object.Length)], Parent);
            _instanceD.transform.position = new Vector3(Parent.position.x, Parent.position.y + 0.5f, Parent.position.z - TileWidthDiv2);
            _instanceD.transform.forward = -1 * Parent.forward;

            GameObject _instanceR = Instantiate(_object[Random.Range(0, _object.Length)], Parent);
            _instanceR.transform.position = new Vector3(Parent.position.x + TileWidthDiv2, Parent.position.y + 0.5f, Parent.position.z);
            _instanceR.transform.forward = Parent.right;

            GameObject _instanceL = Instantiate(_object[Random.Range(0, _object.Length)], Parent);
            _instanceL.transform.position = new Vector3(Parent.position.x - TileWidthDiv2, Parent.position.y + 0.5f, Parent.position.z);
            _instanceL.transform.forward = Parent.right * -1;

            if (predictor)
            {
                DoorU = _instanceU;
                DoorR = _instanceR;
                DoorD = _instanceD;
                DoorL = _instanceL;
                DoorU.SetActive(false);
                DoorR.SetActive(false);
                DoorD.SetActive(false);
                DoorL.SetActive(false);
            }
            else
            {
                WallU = _instanceU;
                WallR = _instanceR;
                WallD = _instanceD;
                WallL = _instanceL;
                WallU.SetActive(false);
                WallR.SetActive(false);
                WallD.SetActive(false);
                WallL.SetActive(false);
            }
        }

        public Tile SetCreator(Chunk Creator)
        {
            _creator = Creator;
            return this;
        }
    }

}