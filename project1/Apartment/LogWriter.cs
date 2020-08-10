using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment
{
    class LogWriter
    {
        public static void PrintLog(string contents)
        {
            DirectoryInfo di = new DirectoryInfo("LogFolder"); // LogFolder 폴더 생성
            if (!di.Exists) // di 경로에 LogFolder 폴더가 존재하지 않다면
            {
                di.Create(); // 폴더 생성
            }
            using (StreamWriter writer = new StreamWriter("LogFolder\\Log.txt", true))
            {
                writer.WriteLine(contents);
            }
        }
    }
}
