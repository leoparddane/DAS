using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WF
{
    /// <summary>
    /// 项目准备流程
    /// </summary>
    public sealed class projectPreparation : NativeActivity
    {
        protected override bool CanInduceIdle
        {
            get { return true; }
        }
        // 定义一个字符串类型的活动输入参数
        public InArgument<object> model { get; set; }
        public OutArgument<bool> result { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(NativeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            object model = context.GetValue(this.model);
            
            
#if DEBUG
            context.SetValue(result, true);
            var instanceID = this.Id;
            context.CreateBookmark(((Model.project)model).id, callback);
#endif

        }
        /// <summary>
        /// 将状态更新为评估状态
        /// </summary>
        /// <param name="context"></param>
        /// <param name="bookmark"></param>
        /// <param name="value"></param>
        public void callback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            
        }
    }
}
