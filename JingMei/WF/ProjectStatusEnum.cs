using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF
{
    public enum ProjectStatusEnum
    {
        ProjectInit=1,//项目准备
        ProjectEvaluation,//项目评估
        ProjectStart,//项目启动
        DesignProject,//图纸设计、方案确定
        DiagramDesignProject,//图纸设计
        DemoMaker,//样品制作、测试并送样
        Check,//客户对样品确认、评估
        ProjectNG,//项目NG
        Finish,//项目完成-当前代表的是小批量生产
        TestNG=11,//测试NG
        NO,//客户样品确认过程确认不通过
        DemoOK,//样品制作测试OK
        ProjectOK,//方案OK
    }
}
