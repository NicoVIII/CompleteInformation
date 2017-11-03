namespace CompleteInformation.Recipes.Types

open Chiron

module Recipe =
    type T =
        {
            name: string;
            ingredients: string list;
            recipetext: string option;
        }
        static member ToJson (x:T) = json {
            do! Json.write "name" x.name
            do! Json.write "ingredients" x.ingredients
            do! Json.write "recipetext" x.recipetext
        }
        static member FromJson (_:T) = json {
            let! n = Json.read "name"
            let! i = Json.read "ingredients"
            let! r = Json.read "recipetext"
            return { name = n; ingredients = i; recipetext = r }
        }

    let createEmpty() = {
        name = "";
        ingredients = [];
        recipetext = None;
    }

    let setName (recipe:T) name =
        { recipe with name = name }

    let getName recipe = recipe.name

    let addIngredient recipe ingredient =
        { recipe with ingredients = ingredient::recipe.ingredients }

    let getIngredients recipe = recipe.ingredients |> List.rev

    let setText (recipe:T) text =
        match text with
        | "" -> { recipe with recipetext = None }
        | text -> { recipe with recipetext = Some text }

    let getText recipe =
        match recipe.recipetext with
        | Some text -> text
        | None -> ""
