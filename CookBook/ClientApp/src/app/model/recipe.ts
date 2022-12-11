import { IngredientEntry } from "./ingredient-entry";
import { PreparationStep } from "./preparationstep";

export interface Recipe {
  id?: number;
  title: string;
  description: string;
  suitableFor: number;
  categoryIds: number[];
  ingredientEntries: IngredientEntry[];
  preparation: PreparationStep[];
}
