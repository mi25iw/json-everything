using System.Text.Json;
using NUnit.Framework;

namespace Json.Schema.ArrayExt.Tests;

[SetUpFixture]
public class TestEnvironment
{
	public static readonly JsonSerializerOptions SerializerOptions =
		new JsonSerializerOptions()
			.WithJsonSchema()
			.WithArrayExtVocab();

	[OneTimeSetUp]
	public void Setup()
	{
		Vocabularies.Register();
		EvaluationOptions.Default.OutputFormat = OutputFormat.Hierarchical;
	}
}