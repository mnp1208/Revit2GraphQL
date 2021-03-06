﻿namespace RevitGraphQLSchema
{
    public static class GraphQLSchema
    {
        public static readonly string schema = @"
            
type QLFamilyCategory{
	id: String
	name: String
	qlFamilies(
		nameFilter: [String] = []
	): [QLFamily]
	qlFamilyInstances(
		nameFilter: [String] = []
	): [QLFamilyInstance]
}

type QLFamily{
	id: String
	name: String
	qlFamilySymbols(
		nameFilter: [String] = []
	): [QLFamilySymbol]
	qlFamilyInstances(
		nameFilter: [String] = []
	): [QLFamilyInstance]
}

type QLFamilySymbol{
	id: String
	name: String
	qlFamilyInstances(
		nameFilter: [String] = []
	): [QLFamilyInstance]
}

type QLFamilyInstance{
	id: String
	name: String
	qlParameters(
		nameFilter: [String] = []
	): [QLParameter]
}

type QLFabricationPart{
	id: String
	name: String
	qlParameters(
		nameFilter: [String] = []
	): [QLParameter]
}

type QLParameter{
	id: String
	name: String
	value: String
	userModifiable: Boolean
	isReadOnly: Boolean
}

input UpdateQLParameter{
	instanceId: String
	parameterId: String
	updateValue: String
}

type QLViewSchedule{
	id: String
	name: String
	qlViewScheduleData: QLViewScheduleData
}

type QLViewScheduleData{
	headers: [String]
	rows: [QLViewScheduleRow]
}

type QLViewScheduleRow{
	id: String
	cells: [String]
}

type QLMepSystem{
	id: String
	name: String
	mepDomain: String
	qlTammTreeNode: QLTammTreeNode
}

type QLTammTreeNode{
	id: String
	text: String
	children: [QLTammTreeNode]
}

type QLElementCollection{
	elementIds: [String]
	qlFamilyInstances(
		nameFilter: [String] = []
	): [QLFamilyInstance]
	qlFabricationParts(
		nameFilter: [String] = []
	): [QLFabricationPart]
}

type QLAssembly{
	id: String
	name: String
	hasViews: Boolean
	qlElementCollection: QLElementCollection
}

type QLFabricationService{
	id: String
	name: String
	qlFabricationParts(
		nameFilter: [String] = []
	): [QLFabricationPart]
}

type Query{
	hello: String
	sheets: [String]
	phases: [String]
	qlMepSystems(
		nameFilter: [String] = []
	): [QLMepSystem]
	qlAssemblies(
		nameFilter: [String] = []
	): [QLAssembly]
	qlFabricationServices(
		nameFilter: [String] = []
	): [QLFabricationService]
	qlViewSchedules(
		nameFilter: [String] = []
	): [QLViewSchedule]
	qlFamilyCategories(
		nameFilter: [String] = []
	): [QLFamilyCategory]
	qlFamilies(
		nameFilter: [String] = []
	): [QLFamily]
	qlElementSelection(
		nameFilter: [String] = []
	): QLElementCollection
}

type Mutation{
	qlParameters(
		input: [UpdateQLParameter] = []
	): [QLParameter]
}
schema{
	query: Query,
	mutation: Mutation
}
            ";

    }
}
