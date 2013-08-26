using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace OgameFarmer
{
    class CommonInfo : BaseInfo
    {

        #region static
        internal static const string XPATH_BALL_NAME = "//*[@id=\"planetNameHeader\"]";
        internal static const string XPATH_METAL = "//*[@id=\"metalx\"]";
        internal static const string XPATH_METAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td";
        internal static const string XPATH_CRYSTAL = "//*[@id=\"crystalx\"]";
        internal static const string XPATH_CRYSTAL_STORE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[2]";
        internal static const string XPATH_H = "//*[@id=\"deuteriumx\"]";
        internal static const string XPATH_H_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[3]";
        internal static const string XPATH_ENERGY = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[3]/td[4]";
        internal static const string XPATH_ENERGY_STROE = "/html/body/div[2]/center/table[2]/tbody/tr/td[2]/table/tbody/tr[4]/td[4]";

        internal static const string XPATH_BALL_LIST = "/html/body/div[2]/center/table[2]/tbody/tr/td/center/table/tbody/tr/td[2]/select";

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

        private string metal;

        internal string Metal
        {
            get { return metal; }
            set { metal = value; }
        }

        private string metalStore;

        internal string MetalStore
        {
            get { return metalStore; }
            set { metalStore = value; }
        }

        private string crystal;

        internal string Crystal
        {
            get { return crystal; }
            set { crystal = value; }
        }

        private string crystalStore;

        internal string CrystalStore
        {
            get { return crystalStore; }
            set { crystalStore = value; }
        }

        private string h;

        internal string H
        {
            get { return h; }
            set { h = value; }
        }

        private string hStore;

        internal string HStore
        {
            get { return hStore; }
            set { hStore = value; }
        }

        private string energy;

        internal string Energy
        {
            get { return energy; }
            set { energy = value; }
        }

        private string energyStroe;

        internal string EnergyStroe
        {
            get { return energyStroe; }
            set { energyStroe = value; }
        }

        private ArrayList balllist;

        internal ArrayList Balllist
        {
            get { return balllist; }
            set { balllist = value; }
        }
    }
}
