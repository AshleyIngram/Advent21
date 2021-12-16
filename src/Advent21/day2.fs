namespace Advent21

module Day2 =  
    type Position = { Horizontal: int; Depth: int; Aim: int; }
    type Direction = { Direction: string; Value: int; }
    
    let private parseInstructions (input: seq<string>) =           
        let tryToInt (s: string) = 
            match System.Int32.TryParse s with
            | true, v -> Some v
            | false, _ -> None

        let (|Instruction|_|) (s: string) =
            let parts = s.Split(' ')

            if (parts.Length <> 2 || Option.isNone (tryToInt parts.[1])) then None else
                let value = int parts.[1]
                match parts.[0] with
                | "forward" -> Some ({ Direction = "forward"; Value = value })
                | "up" -> Some ({ Direction = "up"; Value = value })
                | "down" -> Some ({ Direction = "down"; Value = value })
                | _ -> None
        
        input |> Seq.map (fun i ->
            match i with
            | Instruction i -> i
            | _ -> raise <| invalidArg "instruction" i
        )

    let processInstructions instructions forward up down =
        let initialState = { Horizontal = 0; Depth = 0; Aim = 0; }
        
        (initialState, instructions) ||> Seq.fold (fun state instruction ->
            match instruction.Direction with
            | "forward" -> forward state instruction
            | "up" -> up state instruction
            | "down" -> down state instruction
            | _ -> raise <| invalidArg "instruction" instruction.Direction
        )
        |> (fun state -> state.Horizontal * state.Depth) 

    let part1 (inputStrings: seq<string>) =
        let instructions = parseInstructions inputStrings

        let forward state i = { state with Horizontal = state.Horizontal + i.Value; }
        let up state i = { state with Depth = state.Depth - i.Value; }
        let down state i = { state with Depth = state.Depth + i.Value; }

        processInstructions instructions forward up down

    let part2 (inputStrings: seq<string>) =
        let instructions = parseInstructions inputStrings

        let forward state instruction = { state with Horizontal = state.Horizontal + instruction.Value; Depth = state.Depth + (instruction.Value * state.Aim); }
        let up state instruction = { state with Aim = state.Aim - instruction.Value; }
        let down state instruction = { state with Aim = state.Aim + instruction.Value }

        processInstructions instructions forward up down