﻿using System;
using System.Collections.Generic;

namespace Json.Path;

/// <summary>
/// Defines properties and methods required for an expression function.
/// </summary>
/// <remarks>Functions must be registered with <see cref="FunctionRepository.Register(IPathFunctionDefinition)"/></remarks>
public interface IPathFunctionDefinition
{
	/// <summary>
	/// Gets the function name.
	/// </summary>
	string Name { get; }
	/// <summary>
	/// The minimum argument count accepted by the function.
	/// </summary>
	int MinArgumentCount { get; }
	/// <summary>
	/// The maximum argument count accepted by the function.
	/// </summary>
	int MaxArgumentCount { get; }

	/// <summary>
	/// Defines the sets of parameters that are valid for this function.
	/// </summary>
	/// <remarks>
	/// The value of this property is a collection of collections where
	/// each inner collection represents a single parameter set.  The
	/// outer collection represents differing parameter sets and can
	/// be thought of as "overloads."
	/// </remarks>
	IEnumerable<IEnumerable<ParameterType>> ParameterSets { get; }

	/// <summary>
	/// The type returned by the function.
	/// </summary>
	/// <remarks>
	/// This is important for function composition: using a function
	/// as a parameter of another function.
	/// </remarks>
	FunctionType ReturnType { get; }

	/// <summary>
	/// Evaluates the function.
	/// </summary>
	/// <param name="arguments">A collection of nodelists where each nodelist in the collection corresponds to a single argument.</param>
	/// <returns>A nodelist.  If the evaluation fails, an empty nodelist is returned.</returns>
	NodeList Evaluate(IEnumerable<NodeList> arguments);
}

public enum FunctionType
{
	Unspecified,
	Value,
	Boolean,
	NodeList
}

[Flags]
public enum ParameterType
{
	Unspecified,
	Object,
	Array,
	String,
	Number,
	Boolean,
	Null,
	Nothing
}