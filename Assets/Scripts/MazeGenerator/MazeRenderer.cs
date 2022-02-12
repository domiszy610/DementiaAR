using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField, Range(1, 20)]
    private int width = 20;

    [SerializeField, Range(1, 20)]
    private int height = 20;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab;

    [SerializeField]
    private Transform floorPrefab;

    #endregion

    #region Private Fields

    private GameObject rightWalls;
    private GameObject leftWalls;
    private GameObject bottomWalls;
    private GameObject topWalls;

    #endregion

    #region Unity Callbacks

    private void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        GameObject mazeObject = Draw(maze);
    }

    #endregion

    #region Public Methods

    public void SetParentObject(GameObject parentOb, GameObject childObject)
    {
        childObject.transform.SetParent(parentOb.transform);
    }

    #endregion

    #region Private Methods

    private GameObject Draw(WallState[,] maze)
    {
        GameObject mazeObject = new GameObject("Maze");
        GameObject mazeComponentsObject = new GameObject("MazeComponents");
        GameObject wallsObj = new GameObject("Walls");
        Transform floor = Instantiate(floorPrefab, transform);

        float widthFloor = width + width * 0.01f;
        float heightFloor = height + height * 0.01f;
        floor.localScale = new Vector3(widthFloor, 0.2f, heightFloor);
        floor.position += new Vector3(-0.5f, -0.5f, -0.5f);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                WallState cell = maze[i, j];
                Vector3 position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    Transform topWall = Instantiate(wallPrefab, transform);
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                    topWalls = topWall.gameObject;
                    //GameObject topWallObj = AddRigidBody(topWalls);
                    SetParentObject(wallsObj, topWalls);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    Transform leftWall = Instantiate(wallPrefab, transform);
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                    leftWalls = leftWall.gameObject;
                    //GameObject leftWallObj = AddRigidBody(leftWalls);
                    SetParentObject(wallsObj, leftWalls);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        Transform rightWall = Instantiate(wallPrefab, transform);
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                        rightWalls = rightWall.gameObject;
                        //GameObject rightWallObj = AddRigidBody(rightWalls);
                        SetParentObject(wallsObj, rightWalls);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        Transform bottomWall = Instantiate(wallPrefab, transform);
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                        bottomWalls = bottomWall.gameObject;
                        //GameObject bottomWallObj = AddRigidBody(bottomWalls);
                        SetParentObject(wallsObj, bottomWalls);
                    }
                }
            }
        }

        GameObject floorObj = floor.gameObject;
        mazeComponentsObject = AddRigidBody(mazeComponentsObject);
        SetParentObject(mazeComponentsObject, floorObj);
        SetParentObject(mazeComponentsObject, wallsObj);
        SetParentObject(mazeObject, mazeComponentsObject);

        return mazeObject;
    }

    private GameObject AddRigidBody(GameObject mazeObject)
    {
        Rigidbody rigidbody = mazeObject.AddComponent<Rigidbody>();
        rigidbody.mass = 1;
        rigidbody.drag = 0;
        rigidbody.angularDrag = 0f;
        rigidbody.interpolation = RigidbodyInterpolation.None;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = false;
        return mazeObject;
    }

    #endregion
}