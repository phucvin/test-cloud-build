namespace Monday
{
    public static class MLog
    {
        public static bool LogDebug = true;
        public static bool LogInfo = true;
        public static bool LogWarning = true;
        public static bool LogError = true;

        private static UnityEngine.Object _context = null;

        public static void WithContext(UnityEngine.Object context)
        {
            _context = context;
        }

        public static void Debug(object str)
        {
            if (LogDebug)
            {
                UnityEngine.Debug.Log(str, popContext());
            }
            else popContext();
        }

        public static void Debug(params object[] parts)
        {
            if (LogDebug)
            {
                UnityEngine.Debug.Log(MText.Append(parts), popContext());
            }
            else popContext();
        }

        public static void DebugFormat(string format, params object[] args)
        {
            if (LogDebug)
            {
                UnityEngine.Debug.Log(MText.Format(format, args), popContext());
            }
            else popContext();
        }

        public static void Info(object str)
        {
            if (LogInfo)
            {
                UnityEngine.Debug.Log(str, popContext());
            }
            else popContext();
        }

        public static void Info(params object[] parts)
        {
            if (LogInfo)
            {
                UnityEngine.Debug.Log(MText.Append(parts), popContext());
            }
            else popContext();
        }

        public static void InfoFormat(string format, params object[] args)
        {
            if (LogInfo)
            {
                UnityEngine.Debug.Log(MText.Format(format, args), popContext());
            }
            else popContext();
        }

        public static void Warning(object str)
        {
            if (LogWarning)
            {
                UnityEngine.Debug.LogWarning(str, popContext());
            }
            else popContext();
        }

        public static void Warning(params object[] parts)
        {
            if (LogWarning)
            {
                UnityEngine.Debug.LogWarning(MText.Append(parts), popContext());
            }
            else popContext();
        }

        public static void WarningFormat(string format, params object[] args)
        {
            if (LogWarning)
            {
                UnityEngine.Debug.LogWarning(MText.Format(format, args), popContext());
            }
            else popContext();
        }

        public static void Error(object str)
        {
            if (LogError)
            {
                UnityEngine.Debug.LogError(str, popContext());
            }
            else popContext();
        }

        public static void Error(params object[] parts)
        {
            if (LogError)
            {
                UnityEngine.Debug.LogError(MText.Append(parts), popContext());
            }
            else popContext();
        }

        public static void ErrorFormat(string format, params object[] args)
        {
            if (LogError)
            {
                UnityEngine.Debug.LogError(MText.Format(format, args), popContext());
            }
            else popContext();
        }

        private static UnityEngine.Object popContext()
        {
            var tmp = _context;
            _context = null;
            return tmp;
        }
    }
}