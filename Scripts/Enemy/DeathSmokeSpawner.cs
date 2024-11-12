public class DeathSmokeSpawner : Spawner<Smoke>
{
    public void Release(Enemy enemy)
    {
        Spawn(transform.position);
    }
}