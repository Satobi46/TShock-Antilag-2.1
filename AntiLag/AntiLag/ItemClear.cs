using Microsoft.Xna.Framework;
using System;
using System.Threading;
using System.Timers;
using Terraria;
using TShockAPI;

namespace AntiLag
{
    internal class ItemClear
    {
        public static bool inprogress = false;
        public static DateTime LastCheck = DateTime.UtcNow;
        public static System.Timers.Timer Timer = new System.Timers.Timer();
        private static string tag = TShock.Utils.ColorTag("HAL9000:", Color.Orange);        

        internal static void AntiLagTimer()
        {
            Timer.Interval = 3000.0;
            Timer.Enabled = true;
            Timer.Elapsed += new ElapsedEventHandler(TimerElapsed);
        }

        internal static void TimerElapsed(object sender, ElapsedEventArgs args)
        {
            bool flag = !inprogress;
            if (flag)
            {
                int num = 0;
                int num2;
                for (int i = 0; i < 400; i = num2 + 1)
                {
                    bool active = Main.item[i].active;
                    if (active)
                    {
                        num2 = num;
                        num = num2 + 1;
                    }
                    num2 = i;
                }
                bool flag2 = num > 150;
                if (flag2)
                {
                    int num3 = 5;
                    inprogress = true;
                    bool flag3 = num > 275;
                    if (flag3)
                    {
                        num3 = 2;
                    }
                    else
                    {
                        bool flag4 = num > 225;
                        if (flag4)
                        {
                            num3 = 5;
                        }
                    }
                    TShock.Utils.Broadcast(string.Format("{0} Discovered {1} trash items. Removing in {2} seconds", tag, num, num3), Color.Silver);
                    Thread.Sleep(1000 * num3);
                    for (int j = 0; j < 400; j = num2 + 1)
                    {
                        bool active2 = Main.item[j].active;
                        if (active2)
                        {
                            Main.item[j].active = false;
                            TSPlayer.All.SendData(PacketTypes.UpdateItemDrop, "", j, 0f, 0f, 0f, 0);
                        }
                        num2 = j;
                    }
                    TShock.Utils.Broadcast(string.Format("{0} All trash items have been cleared", tag), Color.Silver);
                    inprogress = false;
                }
            }
        }
    }
}