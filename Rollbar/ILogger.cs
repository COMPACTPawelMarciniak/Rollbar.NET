﻿namespace Rollbar
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// Defines ILogger interface.
    /// 
    /// NOTE: 
    /// 
    /// All the logging methods of this interface imply asynchronous/non-blocking implementation.
    /// However, the interface defines the method (ILogger AsBlockingLogger(TimeSpan timeout))
    /// that returns a synchronous implementation of ILogger.
    /// This approach allows for easier code refactoring when switching between 
    /// asynchronous and synchronous uses of the logger.
    /// 
    /// Normally, you would want to use asynchronous logging since it has virtually no instrumentational 
    /// overhead on your application execution performance at runtime. It has "fire and forget"
    /// approach to logging. However, in some specific situations, for example, while logging right before 
    /// exiting an application, you may want to use it synchronously so that the application
    /// does not quit before the logging completes.
    /// 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Returns blocking/synchronous implementation of this ILogger.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        ILogger AsBlockingLogger(TimeSpan timeout);

        /// <summary>
        /// Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Log(ErrorLevel level, object obj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Log(ErrorLevel level, string msg, IDictionary<string, object> custom = null);


        /// <summary>
        /// Logs the specified message as critical.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Critical(string msg, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified message as error.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Error(string msg, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified message as warning.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Warning(string msg, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified message as info.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Info(string msg, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified message as debug.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Debug(string msg, IDictionary<string, object> custom = null);

        /// <summary>
        /// Logs the specified error as critical.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Critical(Exception error, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified error as error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Error(Exception error, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified error as warning.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Warning(Exception error, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified error as info.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Info(Exception error, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified error as debug.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Debug(Exception error, IDictionary<string, object> custom = null);

        /// <summary>
        /// Logs the specified object as critical.
        /// </summary>
        /// <param name="traceableObj">The traceable object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Critical(ITraceable traceableObj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as error.
        /// </summary>
        /// <param name="traceableObj">The traceable object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Error(ITraceable traceableObj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as warning.
        /// </summary>
        /// <param name="traceableObj">The traceable object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Warning(ITraceable traceableObj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as info.
        /// </summary>
        /// <param name="traceableObj">The traceable object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Info(ITraceable traceableObj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as debug.
        /// </summary>
        /// <param name="traceableObj">The traceable object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Debug(ITraceable traceableObj, IDictionary<string, object> custom = null);


        /// <summary>
        /// Logs the specified object as critical.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Critical(object obj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as error.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Error(object obj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as warning.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Warning(object obj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as info.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Info(object obj, IDictionary<string, object> custom = null);
        /// <summary>
        /// Logs the specified object as debug.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="custom">The custom data.</param>
        /// <returns></returns>
        ILogger Debug(object obj, IDictionary<string, object> custom = null);
    }
}
