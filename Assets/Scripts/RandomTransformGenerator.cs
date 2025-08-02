using UnityEngine;

public static class RandomTransformGenerator
{
    public static Vector3 CreateRandomTransformNearObject(Transform objectTransform,float maxRadius,float minRadius, float heightOffset, bool ignorIsPos = false)
    {
        for (int i = 0; i < 20; i++)  
        {
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 randomPosition2D = randomDirection * Random.Range(minRadius, maxRadius);
            Vector3 randomPosition = objectTransform.position + new Vector3(randomPosition2D.x, heightOffset, randomPosition2D.y);

            if(ignorIsPos) return randomPosition;

            if (!IsPositionBlocked(randomPosition)) 
            {
                return randomPosition;
            }
        }
        return objectTransform.position; // если ваобще ничего не найдет
    }

    private static bool IsPositionBlocked(Vector3 position) // эта штука проверяет есть ли в точке место
    {
        return Physics.CheckSphere(position, 0.25f);  // 0.25f это радиус проверки
    }
}
