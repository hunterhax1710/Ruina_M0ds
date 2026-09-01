

using Battle.CreatureEffect;
using Sound;
using UnityEngine;

namespace BlackSilence
{
    public class PassiveAbility_BlackSilenceChange : PassiveAbilityBase
    {
        public static string Name = "Perception-blocking Mask";
        public static string Desc = "A Speed die with the lowest Speed becomes untargetable";

        public override bool IsTargetable_theLast()                 //Lowest speed dice untargetable
        {
            return false;
        }       
        private void SetParticle()
        {
            UnityEngine.Object @object = Resources.Load("Prefabs/Battle/SpecialEffect/RedMistRelease_ActivateParticle");
            if (@object != null)
            {
                GameObject gameObject = UnityEngine.Object.Instantiate(@object) as GameObject;
                gameObject.transform.parent = this.owner.view.charAppearance.transform;
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = Vector3.one;
            }
            SingletonBehavior<SoundEffectManager>.Instance.PlayClip("Battle/Kali_Change", false, 1f, null);
        }
        private void PlayChangingEffect()
        {
            if (this._bDoneEffect)
            {
                return;
            }
            this._bDoneEffect = true;
            this.owner.view.ChangeSkin("BlackSilenceMask");
            this.owner.view.charAppearance.ChangeMotion(ActionDetail.Default);
            if (this.aura == null)
            {
                this.aura = SingletonBehavior<DiceEffectManager>.Instance.CreateCreatureEffect(this.path, 1f, this.owner.view, this.owner.view, -1f);
            }
            this.SetParticle();           
        }
        public override void OnRoundStart()
        {
            this.PlayChangingEffect();
        }
        public override void OnRoundStartAfter()
        {
        }

        private CreatureEffect aura;
        private bool _bDoneEffect;
        private string path = "6/RedHood_Emotion_Aura";

    }
}
