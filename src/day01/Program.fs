namespace Day1

open System.IO
open System.Linq

module Functions = 
  
  let bundle (raw: string) : List<string> = raw.Split "\n\n" |> Array.toList

  let injest (filePath: string): string = File.ReadLines(filePath) |> Seq.reduce (fun (a: string) (b: string) -> $"{a}\n{b}") 

  let sum (raw: string) : int = 
    raw.Split "\n"
      |> Array.toList
      |> List.map (fun str -> int(str))
      |> List.sum

  let most (input: string): int = 
    input|> bundle
      |> List.map (fun grp -> sum grp )
      |> List.max

  let top3 (input: string): int =
    let arr = 
      input
      |> bundle
      |> List.map (fun grp -> sum grp )
      |> List.sortDescending
      |> List.toArray
    arr[0..2]
    |> Array.sum
module Program = 
  [<EntryPoint>] 
  let main args = 
    let maxCals = 
      Functions.injest "input.txt"
      |> Functions.most

    printfn $"{maxCals}"

    let top3 = 
      Functions.injest "input.txt"
      |> Functions.top3
    
    printfn $"{top3}"
    0