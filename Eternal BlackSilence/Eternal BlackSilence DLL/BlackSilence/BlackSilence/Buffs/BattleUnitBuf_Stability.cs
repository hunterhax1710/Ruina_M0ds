

using Sound;
using UnityEngine;

namespace BlackSilence
{
    public class BattleUnitBuf_Stability : BattleUnitBuf
    {
        public override string keywordId => "Stability";
        public string KeywordBufName => "Stability";
        public ref KeywordBuf KeywordBuf => ref MyKeywords.Stability;
        public override KeywordBuf bufType
        {
            get
            {
                return this.KeywordBuf;

            }
        }
        public override BufPositiveType positiveType
        {
            get
            {
                return BufPositiveType.None;
            }
        }
        public BattleUnitBuf_Stability(BattleUnitModel model)
        {
            this._owner = model;
            this.stack = 0;
        }
        public override void OnRoundEnd()
        {         
            this.stack--;
            if (this.stack == 0)
            {
                this.Destroy();
                return;
            }
        }
        public static void GainCharge(BattleUnitModel model, int add)
        {
            BattleUnitBuf_Stability battleUnitBuf_Stability = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Stability) as BattleUnitBuf_Stability;
            if (battleUnitBuf_Stability == null)
            {
                battleUnitBuf_Stability = new BattleUnitBuf_Stability(model);
                battleUnitBuf_Stability.Add(add);
                model.bufListDetail.AddBuf(battleUnitBuf_Stability);
                return;
            }
            battleUnitBuf_Stability.Add(add);
        }

        // Token: 0x06001063 RID: 4195 RVA: 0x000497C8 File Offset: 0x000479C8
        public static int GetCharge(BattleUnitModel model)
        {
            BattleUnitBuf_Stability battleUnitBuf_Stablity = model.bufListDetail.GetActivatedBufList().Find((BattleUnitBuf x) => x is BattleUnitBuf_Stability) as BattleUnitBuf_Stability;
            int result;
            if (battleUnitBuf_Stablity == null)
            {
                result = 0;
            }
            else
            {
                result = battleUnitBuf_Stablity.stack;
            }
            return result;
        }

        // Token: 0x06001064 RID: 4196 RVA: 0x00007A6A File Offset: 0x00005C6A
        public void Add(int add)
        {
            this.stack += add;
            if (this.stack >= 2)
            {
                this.stack = 2;
            }
        }
        private void SetParticle()
        {           
            UnityEngine.Object @object = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_Aura");
            if (@object != null)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                gameObject.transform.parent = this._owner.view.charAppearance.transform;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = Vector3.one;
                IndexReleaseAura component = gameObject.GetComponent<IndexReleaseAura>();
                if (component != null)
                {
                    component.Init(this._owner.view);
                }
                this._aura = gameObject;
            }
            UnityEngine.Object object2 = Resources.Load("Prefabs/Battle/SpecialEffect/IndexRelease_ActivateParticle");
            if (object2 != null)
            {
                GameObject gameObject2 = UnityEngine.Object.Instantiate(object2) as GameObject;
                gameObject2.transform.parent = this._owner.view.charAppearance.transform;
                gameObject2.transform.localPosition = Vector3.zero;
                gameObject2.transform.localRotation = Quaternion.identity;
                gameObject2.transform.localScale = Vector3.one;
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Buf/Effect_Index_Unlock", false, 1f, null);
        }
        public override void OnRoundStart()
        {
            this.SetParticle();                      

        }

        public override bool IsImmune(BattleUnitBuf buf)
        {
            return buf.positiveType == BufPositiveType.Negative || buf.bufType == KeywordBuf.Stun || buf.bufType == KeywordBuf.NullifyPower || buf.bufType == KeywordBuf.Seal || buf.bufType == KeywordBuf.SealKeyword;
        }

        // Token: 0x06001061 RID: 4193 RVA: 0x00007A5A File Offset: 0x00005C5A
        public virtual bool IsImmuneDmg(DamageType type)
        {
            return type == DamageType.Buf || base.IsImmuneDmg(type, KeywordBuf.None);
        }
        private string _TRANSFORM_PARTICLE_PATH;

        
        private GameObject _aura;
       

    }
}