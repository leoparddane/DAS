using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WF
{
    /// <summary>
    /// 图纸设计
    /// </summary>
    public sealed class projectDiagramDesign : NativeActivity
    {
        protected override bool CanInduceIdle
        {
            get { return true; }
        }
        // 定义一个字符串类型的活动输入参数
        public InArgument<object> model { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(NativeActivityContext context)
        {
            object model = context.GetValue(this.model);

            //创建书签
            context.CreateBookmark(((Model.project)model).id, callback);
        }
        public void callback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            //更新传入的model的值为最新的值
            //object model = context.GetValue(this.model);

        }
    }
}
