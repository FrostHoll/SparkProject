using UnityEngine;

public class RandomTransformGenerator : MonoBehaviour 
{
    public Vector3 CreateRandomTransformNearObject(Transform objectTransform,float maxRadius,float minRadius, float heightOffset)
    {
        //for (int i = 0; i < 20; i++)  
        //{
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 randomPosition2D = randomDirection * Random.Range(minRadius, maxRadius);
            Vector3 randomPosition = objectTransform.position + new Vector3(randomPosition2D.x, heightOffset, randomPosition2D.y);

            /*
            if (!IsPositionBlocked(randomPosition)) // непонятно. С этой проверкой или без. Маг не хочет тепаться в объекты
            {
                return randomPosition;
            }*/
            return randomPosition;
        //}
        //return transform.position;
    }

    private bool IsPositionBlocked(Vector3 position) // эта штука проверяет есть ли в точке место
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.25f);  // 0.25f это радиус проверки
        return colliders.Length > 0;
    }
}
