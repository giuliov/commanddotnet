﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using CommandDotNet.Execution;

namespace CommandDotNet.ClassModeling.Definitions
{
    internal class NullMethodDef : IMethodDef
    {
        public static readonly IMethodDef Instance = new NullMethodDef();

        private NullMethodDef()
        {
        }

        public IReadOnlyCollection<IArgumentDef> ArgumentDefs { get; } = new IArgumentDef[0];
        public MethodBase MethodBase { get; } = null;

        public IReadOnlyCollection<IArgument> Arguments { get; } = new IArgument[0];
        public IReadOnlyCollection<ParameterInfo> Parameters { get; } = new ParameterInfo[0];
        public object[] ParameterValues { get; } = new object[0];

        public Task<int> InvokeAsMiddleware(CommandContext commandContext, object instance, Func<CommandContext, Task<int>> next)
        {
            return next(commandContext);
        }

        public object Invoke(CommandContext commandContext, object instance)
        {
            // TODO: this should never be hit or it should result in a help exception
            throw new NotImplementedException("We should never reach this");
        }
    }
}