using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    public class SmiteCode
    {
        public enum Lists
        {
            Active = 0,
            Expired = 1
        }

        public Lists currentList { get; set; }
        public string code { get; set; }
        public DateTime Time_GrabbedAt { get; set; }
        public DateTime Time_RedeemingAt { get; set; }
        public DateTime Time_ExpiresAt { get; set; }
        public bool isActive { get; set; }
        public bool isRedeemed { get; set; }

        public void SwitchList()
        {
            if (currentList == Lists.Active)
            {
                currentList = Lists.Expired;
                Globals.shouldUpdateExpiredList = true;
                Globals.shouldUpdateActiveList = true;
            }
            else
            {
                currentList = Lists.Active;
                Globals.shouldUpdateExpiredList = true;
                Globals.shouldUpdateActiveList = true;
            }
        }
        public string GetCode()
        {
            return code;
        }
        public bool GetIsActive()
        {
            if (GetTimeLeft() > 0)
                return true;
            return false;
        }
        public bool GetIsRedeemed()
        {
            return isRedeemed;
        }
        public void SetIsRedeemed(bool status)
        {
            isRedeemed = status;
        }
        public double GetTimeLeft()
        {
            return new TimeSpan(0, 30, 0).Subtract(GetAgeMinutes()).TotalMinutes;
        }
        public string GetTimeLeftString()
        {
            var timespan = new TimeSpan(0, 30, 0).Subtract(GetAgeMinutes());
            return string.Format("{0}:{1:00}",
                (int)timespan.TotalMinutes,
                timespan.Seconds);
        }
        public TimeSpan GetAgeMinutes()
        {
            var timeNow = DateTime.Now;
            var grabbedAt = this.Time_GrabbedAt;
            return timeNow.Subtract(grabbedAt);
        }
        public SmiteCode(string code)
        {
            this.code = code;
            Time_GrabbedAt = DateTime.Now;
            Time_RedeemingAt = DateTime.Now.Add(new TimeSpan(0, Globals.redeemDelay, 0));
            Time_ExpiresAt = Time_GrabbedAt.Add(new TimeSpan(0, 30, 0));
            currentList = Lists.Active;
            isActive = true;
        }
        public SmiteCode(string code, bool isActive)
        {
            this.code = code;
            Time_GrabbedAt = DateTime.Now.Subtract(new TimeSpan(0,30,0));
            Time_RedeemingAt = DateTime.Now.Add(new TimeSpan(0, Globals.redeemDelay, 0));
            Time_ExpiresAt = Time_GrabbedAt.Add(new TimeSpan(0, 30, 0));
            currentList = Lists.Active;
            this.isActive = isActive;
        }
        public SmiteCode(string code, bool isActive, DateTime CreationTime)
        {
            this.code = code;
            Time_GrabbedAt = CreationTime;
            Time_RedeemingAt = DateTime.Now.Add(new TimeSpan(0, Globals.redeemDelay, 0));
            Time_ExpiresAt = Time_GrabbedAt.Add(new TimeSpan(0, 30, 0));
            currentList = Lists.Active;
            this.isActive = isActive;
        }
    }
}