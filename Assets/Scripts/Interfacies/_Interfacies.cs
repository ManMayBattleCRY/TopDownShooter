
namespace Game 
{
    namespace Interfaces
    {
        public interface IDamageble
        {
            public void DamageTaken(float damage);

            public void Die();
        }

        public interface IHealble
        {
            public void DamageTaken(float damage);


        }

        public interface ILocatable
        {
            public void OnDestroy();
        }
    }
}
