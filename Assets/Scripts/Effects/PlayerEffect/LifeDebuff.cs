namespace Assets.Scripts.Effects
{
	public class LifeDebuff : PlayerEffect
	{

		public override void OnEquip()
		{
			PlayerManager.Instance.life -= UnityEngine.Mathf.FloorToInt(value);
		}

		public override void OnUnequip()
		{
			PlayerManager.Instance.life += UnityEngine.Mathf.FloorToInt(value);
		}
	}
}