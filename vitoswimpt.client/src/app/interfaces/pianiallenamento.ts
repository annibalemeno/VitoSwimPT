import { Allenamenti } from "./allenamenti";
import { Piani } from "./piani";

export interface PianiAllenamento {
  piano: Piani;
  allenamentiAssociati: Allenamenti[];
}
