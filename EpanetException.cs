using System;
using System.Collections.Generic;
using System.Text;

namespace EpanetTest
{
    class EpanetException:Exception
    {
        private int errorCode = 0;
        public EpanetException(int errorCode)
        {
            this.errorCode = errorCode;
            switchException(errorCode);
        }

        private void switchException(int errorCode)
        {
            switch (errorCode)
            {
                case 101:
                    Console.WriteLine("没有足够的内存");
                    break;

                case 102:
                    Console.WriteLine("没有需要处理的管网数据");
                    break;

                case 103:
                    Console.WriteLine("水力求解器没有初始化");
                    break;

                case 104:
                    Console.WriteLine("没有可用的水利结果");
                    break;

                case 105:
                    Console.WriteLine("水质求解器没有初始化");
                    break;

                case 106:
                    Console.WriteLine("没有可以报告的结果");
                    break;

                case 110:
                    Console.WriteLine("不能够求解水力方程组");
                    break;

                case 120:
                    Console.WriteLine("不能够求解WQ迁移方程组");
                    break;

                case 200:
                    Console.WriteLine("输入文件中有一处或者多处错误");
                    break;

                case 202:
                    Console.WriteLine("函数调用中具有非法数值");
                    break;

                case 203:
                    Console.WriteLine("函数调用中具有未定义的节点");
                    break;

                case 204:
                    Console.WriteLine("函数中调用中具有未定义的管段");
                    break;

                case 205:
                    Console.WriteLine("函数调用中具有未定义的时间模式");
                    break;

                case 207:
                    Console.WriteLine("试图控制止回阀");
                    break;

                case 223:
                    Console.WriteLine("管网中没有充分的节点");
                    break;

                case 224:
                    Console.WriteLine("管网中不存在水池或水库");
                    break;

                case 240:
                    Console.WriteLine("函数调用中具有未定义的水源");
                    break;

                case 241:
                    Console.WriteLine("函数调用中具有未定义的控制语句");
                    break;

                case 250:
                    Console.WriteLine("函数参数格式非法");
                    break;

                case 251:
                    Console.WriteLine("函数调用中具有非法参数代号");
                    break;

                case 301:
                    Console.WriteLine("相同的文件名");
                    break;

                case 302:
                    Console.WriteLine("不能够打开输入文件");
                    break;

                case 303:
                    Console.WriteLine("不能够打开输出文件");
                    break;

                case 304:
                    Console.WriteLine("不能够打开二进制输出文件");
                    break;

                case 305:
                    Console.WriteLine("不能够打开水力文件");
                    break;

                case 306:
                    Console.WriteLine("非法水力文件");
                    break;

                case 307:
                    Console.WriteLine("不能够阅读水力文件");
                    break;

                case 308:
                    Console.WriteLine("不能够将结果保存到文件");
                    break;

                case 309:
                    Console.WriteLine("不能够将报告写入文件");
                    break;
                default:
                    Console.WriteLine("未定义的异常");
                    break;
                

            }
                
        }
    }
}
