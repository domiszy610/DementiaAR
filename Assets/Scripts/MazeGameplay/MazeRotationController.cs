using UnityEngine;

namespace MazeGameplay
{
    public class MazeRotationController : MonoBehaviour

    {
        private float firstPoint;
        private float secondPoint;

        private int inc = 0;

        void Update()
        {

            if (Input.touchCount == 0)
            {
                inc = 0;

                return;
            }

            if (Input.touchCount == 1)
            {
                if (inc == 0)
                {
                    firstPoint = (int) Input.GetTouch(0).position.x;
                    secondPoint = (int) Input.GetTouch(0).position.x;
                }

                inc++;

                if (inc <= 10)
                {
                    return;
                }

                secondPoint = (int) Input.GetTouch(0).position.x;

                if (firstPoint < secondPoint)
                {
                    Rotate(false);
                }
                else if (firstPoint > secondPoint)
                {
                    Rotate(true);
                }
            }
        }


        private void LateUpdate()
        {
            if (inc >= 10)
            {
                firstPoint = (int) Input.GetTouch(0).position.x;
            }
        }

        void Rotate(bool rightRotation)
        {

            //Debug.Log(m_right);

            if (rightRotation)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 80f);
            }
            else
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 80f);
            }
        }
    }
}