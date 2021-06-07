using System;
using UnityEngine;

namespace SilverRogue.Tools
{
    /// <summary>
    /// A generic timer that can be used to replace self-made timers in scripts.
    /// Countsdown from the given startTime to zero. Has properties which can be used in checks to 
    /// see if the timer, for example: has expired or is still running.
    /// 
    /// Timers require a reference to a <see cref="UpdateCaller"/>. So make sure a UpdateCaller
    /// is accessible within the scene.
    /// </summary>
    public class Timer
    {
        public Action timerExpiredEvent = delegate { };

        public bool Expired { get; private set; }
        public bool Running { get; private set; }
        public bool Paused { get; private set; }
        public float TimeLeft => time;

        private float time;
        private float startTime;
        private bool useGameTime;

        public Timer(float time, bool startPlaying = true, bool useGameTime = false)
        {
            if(time < 0)
            {
                time *= -1;
            }
            else if(time == 0)
            {
                Debug.LogError("Timer has started with a value of zero.");
            }

            this.time = time;
            this.useGameTime = useGameTime;
            startTime = time;

            if(startPlaying)
            {
                Running = true;
                Paused = false;
            }
            else
            {
                Running = false;
                Paused = true;
            }

            Expired = false;

            UpdateCaller.AddUpdateCallback(Update);
        }

        /// <summary>
        /// This method gets subscribed to the UpdateCaller
        /// </summary>
        private void Update()
        {
            if(Running && !Paused)
            {
                if(useGameTime)
                {
                    time -= 1f * GameTime.deltaTime;
                }
                else
                {
                    time -= 1f * Time.deltaTime;
                }

                if(time <= 0)
                {
                    Expired = true;
                    Running = false;

                    timerExpiredEvent.Invoke();
                }
            }
        }

        /// <summary>
        /// Activate the timer ( if it isn't already expired or playing )
        /// </summary>
        public void Play()
        {
            if(!Expired)
            {
                if(Running)
                {
                    Debug.LogWarning(this + " timer is already playing, so you cannot play again.");
                }

                Running = true;
                Paused = false;
            }
            else
            {
                Debug.LogWarning(this + " timer is already expired, so you cannot play, Use 'RestartTimer' instead.");
            }
        }

        /// <summary>
        /// Pause the timer ( if it isn't already expired or paused )
        /// </summary>
        public void Pause()
        {
            if(!Expired)
            {
                if(Paused)
                {
                    Debug.LogWarning(this + " timer is already paused, so you cannot pause again");
                }

                Paused = true;
            }
            else
            {
                Debug.LogWarning(this + " timer is already expired, so you cannot resume");
            }
        }

        /// <summary>
        /// Resume the timer ( if it isn't already expired or resumed )
        /// </summary>
        public void Resume()
        {
            if(!Expired)
            {
                if(!Paused)
                {
                    Debug.LogWarning(this + " timer is already running, so you cannot resume again");
                    return;
                }

                Paused = false;
            }
            else
            {
                Debug.LogWarning(this + " timer is already expired, so you cannot resume");
            }
        }

        /// <summary>
        /// Restart the timer with the default value or if a parameter is 
        /// passed with the new time.
        /// </summary>
        public void Restart(bool clearExpiredEvent = false, float newStartTime = 0f)
        {
            if(clearExpiredEvent)
            {
                timerExpiredEvent = delegate { };
            }

            if(newStartTime != 0f)
            {
                startTime = newStartTime;
            }

            time = startTime;
            Running = true;
            Expired = false;
        }
    }
}