using System;
using System.Reflection;
using Terraria;
using TerrariaApi.Server;

namespace AntiLag
{
    [ApiVersion(2, 1)]
    public class AntiLag : TerrariaPlugin
    {
        public override string Author => "Jewsus";
        public override string Name => "AntiLag";
        public override string Description => "Clears trash items";
        public override Version Version => Assembly.GetExecutingAssembly().GetName().Version;

        public AntiLag(Main game) : base(game)
        {
            Order = 0;
        }

        public override void Initialize()
        {
            Intro.PrintIntro();
            ItemClear.AntiLagTimer();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
    }
}