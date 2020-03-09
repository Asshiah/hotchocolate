using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;
using StrawberryShake.CodeGeneration.Analyzers.Models;
using StrawberryShake.CodeGeneration.Utilities;

namespace StrawberryShake.CodeGeneration.Analyzers
{
    internal interface IDocumentAnalyzerContext
    {
        ISchema Schema { get; }

        IReadOnlyCollection<ITypeModel> Types { get; }

        NameString GetOrCreateName(
            ISyntaxNode node,
            NameString name,
            ISet<string>? skipNames = null);

        PossibleSelections CollectFields(
            INamedOutputType type,
            SelectionSetNode selectionSet,
            Path path);

        void Register(ComplexOutputTypeModel type);

        void Register(FieldParserModel parser);

        // IReadOnlyDictionary<FieldNode, string> FieldTypes { get; }
        /*
        bool TryGetDescriptor<T>(string name, out T? descriptor)
            where T : class, ICodeDescriptor;

        void Register(FieldNode field, ICodeDescriptor descriptor);

        void Register(ICodeDescriptor descriptor, bool update);

        void Register(ICodeDescriptor descriptor);
        */
    }
}