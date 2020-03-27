using System;

namespace Graphene.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MessageOrderAttribute : Attribute
    {
        public readonly int Value;

        public MessageOrderAttribute(int value)
        {
            Value = value;
        }
    }
}