using System;
using System.Text;

namespace Monday
{
    public static class MText
    {
        public static string Append(params object[] parts)
        {
            var sb = MStringBuilderCache.Acquire();
            for (int i = 0, n = parts.Length; i < n; ++i)
            {
                sb.Append(parts[i]);
            }
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string Append(object part1, object part2)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.Append(part1).Append(part2);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string Append(object part1, object part2, object part3)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.Append(part1).Append(part2).Append(part3);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string AppendWithSeparator(string separator, params object[] parts)
        {
            var sb = MStringBuilderCache.Acquire();
            for (int i = 0, endI = parts.Length - 1; i <= endI; ++i)
            {
                sb.Append(parts[i]);
                if (i < endI)
                {
                    sb.Append(separator);
                }
            }
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string AppendWithSeparator(string separator, object part1, object part2)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.Append(part1).Append(separator).Append(part2);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string AppendWithSeparator(string separator, object part1, object part2, object part3)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.Append(part1).Append(separator).Append(part2).Append(separator).Append(part3);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string Format(string format, object arg)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.AppendFormat(format, arg);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }

        public static string Format(string format, params object[] args)
        {
            var sb = MStringBuilderCache.Acquire();
            sb.AppendFormat(format, args);
            return MStringBuilderCache.GetStringAndRelease(sb);
        }
    }

    public static class MStringBuilderCache
    {
        private const int MaxCapacityToKeep = 512;

        [ThreadStatic]
        private static StringBuilder _sb;

        public static StringBuilder Acquire()
        {
            var sb = _sb;
            if (sb != null)
            {
                _sb = null;
                sb.Length = 0;
                return sb;
            }
            return new StringBuilder();
        }

        public static void Release(StringBuilder sb)
        {
            // Do not keep too large memory
            if (sb.Capacity > MaxCapacityToKeep) return;

            if (_sb != null)
            {
                // But keep larger capacity to reduce memory fragmentation
                _sb = _sb.Capacity > sb.Capacity ? _sb : sb;
            }
            else
            {
                _sb = sb;
            }
        }

        public static string GetStringAndRelease(StringBuilder sb)
        {
            string result = sb.ToString();
            Release(sb);
            return result;
        }
    }
}