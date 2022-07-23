using System;
using System.Collections.Generic;
using System.Text;

namespace DamageCalculatorGUI
{
    class SwordDamage
    {
        /// <summary>
        /// Constructor calcs damage based on default Magic and Flaming values and a starting 3d6 roll.
        /// </summary>
        /// <param name="startingRoll">starting 3d6 roll</param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }


        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        private int roll;

        /// <summary>
        /// Sets or gets the 3d6 roll.
        /// </summary>
        public int Roll { get { return roll; } set { roll = value; CalculateDamage(); } }


        private bool flaming;
        /// <summary>
        /// True if sword is flaming. False otherwise.
        /// </summary>
        public bool Flaming { get { return flaming; } set { flaming = value; CalculateDamage(); } }

        private bool magic;

        /// <summary>
        /// True if sword is magic. False otherwise.
        /// </summary>
        public bool Magic { get { return magic; } set { magic = value; CalculateDamage(); } }

        /// <summary>
        /// Contains the calculated damage.
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Calcs damage based on current properties.
        /// </summary>
        private void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }
    }
}
