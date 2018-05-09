open System

module Program = 
    let [<EntryPoint>] main _ =
      let tokensH = Console.ReadLine().Split(' ')
      let h = int32 tokensH.[0]
      let w = int32 tokensH.[1]
      let cube = Array2D.create h w 0
      for r in 0..h-1 do
        let tokensW = Console.ReadLine().Split(' ')
        for c in 0..w-1 do
            cube.[r,c] <- int tokensW.[c]
      Console.WriteLine(Calculator.CalculateWholeCube cube)
      0
