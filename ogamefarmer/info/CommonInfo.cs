using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace OgameFarmer
{
    internal class CommonInfo : BaseInfo
    {

        #region static
        internal const string XPATH_METAL = "//*[@id=\"metalx\"]";
        internal const string XPATH_METAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td";
        internal const string XPATH_CRYSTAL = "//*[@id=\"crystalx\"]";
        internal const string XPATH_CRYSTAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[2]";
        internal const string XPATH_H = "//*[@id=\"deuteriumx\"]";
        internal const string XPATH_H_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[3]";
        internal const string XPATH_ENERGY = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[3]/td[4]";
        internal const string XPATH_ENERGY_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[4]";

        internal const string XPATH_BALL_LIST = "/html/body/div[2]/center/table[2]/tbody/tr/td/center/table/tbody/tr/td[2]/select";
        //internal const string XPATH_BALL_LIST = "//option";

        #endregion

        private string currentBallName;

        internal string CurrentBallName
        {
            get { return currentBallName; }
            set { currentBallName = value; }
        }

        private int[] currentBallCursor = new int[3];

        internal int[] CurrentBallCursor
        {
            get { return currentBallCursor; }
            set { currentBallCursor = value; }
        }

        private int metal;

        internal int Metal
        {
            get { return metal; }
            set { metal = value; }
        }

        private int metalStore;

        internal int MetalStore
        {
            get { return metalStore; }
            set { metalStore = value; }
        }

        private int crystal;

        internal int Crystal
        {
            get { return crystal; }
            set { crystal = value; }
        }

        private int crystalStore;

        internal int CrystalStore
        {
            get { return crystalStore; }
            set { crystalStore = value; }
        }

        private int h;

        internal int H
        {
            get { return h; }
            set { h = value; }
        }

        private int hStore;

        internal int HStore
        {
            get { return hStore; }
            set { hStore = value; }
        }

        private int energy;

        internal int Energy
        {
            get { return energy; }
            set { energy = value; }
        }

        private int energyStroe;

        internal int EnergyStroe1
        {
            get { return energyStroe; }
            set { energyStroe = value; }
        }

        internal int EnergyStroe
        {
            get { return energyStroe; }
            set { energyStroe = value; }
        }

        private ArrayList balllist = new ArrayList();

        internal ArrayList Balllist
        {
            get { return balllist; }
            set { balllist = value; }
        }

        public override string ToString()
        {
            //return currentBallName + "    " + currentBallCursor;
            return currentBallName;
        }

        internal class Ball
        {
            private string name;

            internal string Name
            {
                get { return name; }
                set { name = value; }
            }

            private string location;

            internal string Location
            {
                get { return location; }
                set { location = value; }
            }

            private string accessParm;

            internal string AccessParm
            {
                get { return accessParm; }
                set { accessParm = value; }
            }
        }
    }
}
