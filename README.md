# Functional-Block-System-Unity
Functional block system with JSON serialization - Unity 6000.3.2f1

# Overview :

This project implements a modular, data-driven functional block system in Unity. The system
enables dynamic creation and manipulation of scene objects using a block-based architecture
similar to node-based programming systems.

# Architecture Overview :

• BaseBlock: Abstract definition for all block types.

• BlockExecutionContext: Stores runtime state including created objects and variables.

• Action Blocks: CreateObjectBlock, MoveBlock, RotateBlock, ScaleBlock.

• Logic Blocks: SetVariableBlock, CompareBlock.

• BlockGraphExecutor: Traverses blocks using ID-based execution flow.

• GraphSerializer: Handles polymorphic JSON export and import using reflection.

# Execution Flow :

Execution begins from a defined start block. Each block performs a specific operation and returns
the ID of the next block to execute. This enables dynamic branching and deterministic traversal.

# JSON Serialization :

The block graph configuration can be exported to JSON format and re-imported at runtime. Type
metadata is stored alongside block data to ensure accurate polymorphic reconstruction using
reflection during deserialization.

# Demo Controls :

• Press S: Export the current block graph to JSON.

• Press L: Import the saved JSON and re-execute the graph.

# Design Decisions :

• ID-based block traversal ensures safe and serializable execution flow.

• Separation of concerns between blocks, execution engine, and persistence layer.

• Use of context object to maintain runtime state without tight coupling.

• Extensible architecture allowing new block types without modifying the executor.

# Conclusion :

This implementation fulfills all assignment requirements including object creation, manipulation,
logical branching, and JSON persistence. The architecture emphasizes clarity, scalability, and
maintainability.
