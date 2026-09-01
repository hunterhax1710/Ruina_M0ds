using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace BlackSilence
{
       
    public class PassiveAbility_Shimmering : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            patternCount = 0;
            special = 4;
        }



        public override void OnRoundStart()
        {           
            if (special >= 4 && !this.owner.IsBreakLifeZero())                                   //4 Scene cooldown special
            {
                AddNewCard2(1001);
                special = 0;
            }
            if (phase == 2 && ultimate >= 7 && !this.owner.IsBreakLifeZero())                    //7 Scene cool down ultimate Storm
            {
                AddNewCard2(10031);
                ultimate = 0;
            }
            if (phase2 == 3 && ultimate2 >= 7 && !this.owner.IsBreakLifeZero())                    //7 Scene cool down ultimate2 Furioso
            {
                AddNewCard2(10121);                
                ultimate2 = 0;
            }
            if (last == 1 && ultimate3 >= 6 && !this.owner.IsBreakLifeZero())                    //6 Scene cool down ultimate3 Silence
            {
                AddNewCard2(10131);
                ultimate3 = 0;
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) >= 3 && phase != 2)
            {
                phase = 2;
                AddNewCard2(10031);
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) >= 4 && phase2 != 3)
            {
                phase2 = 3;               
                AddNewCard2(10121);
            }
            if (BattleUnitBuf_Returner.GetCharge(owner) >= 5 && last != 1)
            {
                last = 1;
                AddNewCard2(10131);               
            }
            this.owner.cardSlotDetail.RecoverPlayPoint(10);           
            SetCards();
            if (patternCount == 3)
            {
                patternCount = 0;
            }
            else
            {
                patternCount++;
            }
        }

        public override void OnRoundEnd()
        {
            this.owner.allyCardDetail.ExhaustAllCards();
            special++;           
            if (phase == 2)
            {
               ultimate++;               
            }
            if (phase2 == 3)
            {
                ultimate2++;
            }
            if (last == 1)
            {
                ultimate3++;
            }
        } 
        public void SetCards()
        {            
            if (patternCount == 0)
            {             
                AddNewCard(1002);
                AddNewCard(1002);
                AddNewCard(1004);
                AddNewCard(1004);              
                AddNewCard(1005);
                AddNewCard(1010);
                AddNewCard(1008);                              
            }
            if (patternCount == 1)
            {               
                AddNewCard(1008);
                AddNewCard(1007);
                AddNewCard(1007);
                AddNewCard(1005);
                AddNewCard(1005);
                AddNewCard(1006);
                AddNewCard(1006);
            }
            if (patternCount == 2)
            {               
                AddNewCard(1010);
                AddNewCard(1011);
                AddNewCard(1011);
                AddNewCard(1008);               
                AddNewCard(1004);
                AddNewCard(1006);
                AddNewCard(1006);
            }
            if (patternCount == 3)
            {                               
                AddNewCard(1006);
                AddNewCard(1005);
                AddNewCard(1005);
                AddNewCard(1007);
                AddNewCard(1011); 
                AddNewCard(1010);
                AddNewCard(1010);
            }
        }
        

            private void AddNewCard(int id)
        {
            BattleDiceCardModel battleDiceCardModel = this.owner.allyCardDetail.AddNewCard(new LorId("BlackSilence", id), false);
            if (battleDiceCardModel != null)
            {                
                battleDiceCardModel.SetPriorityAdder(9);
            }
        }
        private void AddNewCard2(int id)
        {
            BattleDiceCardModel battleDiceCardModel = this.owner.allyCardDetail.AddNewCard(new LorId("BlackSilence", id), false);
            if (battleDiceCardModel != null)
            {
                battleDiceCardModel.SetPriorityAdder(10);
            }
        }

        
        private int patternCount;
        private int special;
        private int ultimate;
        private int ultimate2;
        private int ultimate3;
        private int phase;
        private int phase2;
        private int last;
    }

}
