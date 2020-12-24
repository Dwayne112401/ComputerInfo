using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"操作系统版本：     {Computer.OSDescription}");
            Console.WriteLine($"操作系统架构：     {Computer.OSArchitecture}");
            Console.WriteLine($"是否为Windows系统：{Computer.OSArchitecture}");
            Console.WriteLine($"计算机名称：       {Computer.ComputerName}");
            Console.WriteLine($"计算机用户：       {Computer.UserName}");

            Console.WriteLine("-------------------------电脑型号-------------------------");
            Console.WriteLine(Computer.GetComputerVersion());

            Console.WriteLine("-------------------------主板信息-------------------------");
            Console.WriteLine(Computer.GetBaseBoardInfo());

            Console.WriteLine("-------------------------处理器信息------------------------");
            Console.WriteLine(Computer.GetCPUInfo());

            Console.WriteLine("-------------------------内存信息-------------------------");
            Console.WriteLine(Computer.GetRAMInfo());

            Console.WriteLine("-------------------------显卡信息-------------------------");
            Console.WriteLine(Computer.GetGPUInfo());

            Console.WriteLine("-------------------------硬盘信息-------------------------");
            Console.WriteLine(Computer.GetDiskInfo());
            Console.ReadKey();
        }
    }


}
