namespace Day1

open System.IO

module Functions = 
  
  let bundle (raw: string) : List<string> = raw.Split "\n\n" |> Array.toList

  let injest (filePath: string): string = File.ReadLines(filePath) |> Seq.reduce (fun (a: string) (b: string) -> $"{a}\n{b}") 

  let sum (raw: string) : int = 
    raw.Split "\n"
      |> Array.toList
      |> List.map (fun str -> int(str))
      |> List.sum

  let most (input: string): int = 
    input
      |> bundle
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
    let input = Functions.injest "input.txt"

    printfn $"{input |> Functions.most}\tIs the most a single elf has"
    printfn $"{input |> Functions.top3}\tIs the total carried by the 3 elfs with the most"
    0