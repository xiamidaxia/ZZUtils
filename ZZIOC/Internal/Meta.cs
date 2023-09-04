using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ZZIOC.Internal
{
    internal interface IMeta
    {
        Type IntefaceType { get; }
        Type OwnerType { get;  }
        Lifestyle Lifestyle { get; }
        
        void EmitNewInstance(CompilationContext context, ILGenerator il, bool forceEmit = false);

        Delegate EmittedDelegate { get; set; }
    }

    internal class Meta : IMeta
    {
        public Type InterfaceType { get; }
        public Type OwnerType { get; }
        public Type Type { get; }
        public TypeInfo TypeInfo { get; }
        public Lifestyle Lifestyle { get; }
        public ConstructorInfo Constructor { get; }
        public FieldInfo[] InjectFields { get; }
        public PropertyInfo[] InjectProperties { get; }
        public MethodInfo[] InjectMethods { get; }
        public Delegate EmittedDelegate { get; set; }

        public Meta(Type interfaceType, Type type, Lifestyle lifestyle)
        {
            this.InterfaceType = interfaceType;
            this.Type = type;
            this.OwnerType = type;
            this.TypeInfo = type.GetTypeInfo();
            this.Lifestyle = lifestyle;
            if (TypeInfo.IsValueType)
            {
                throw new Exception("Does not support ValueType, type:" + type.Name);
            }
        }
    }
}