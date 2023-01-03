import { EntityBase } from '../entity-base.model';
import { User } from '../user/user.model';
import { CodeLibrary } from '../code-library/code-library.model';
import { Language } from '../enum/language.model';
import { CodeType } from '../enum/code-type.model';
export interface CodeSnippet extends EntityBase {
  name: string;
  description?: string | null;
  content?: string | null;
  user?: User | null;
  library?: CodeLibrary | null;
  /**
   * 0 = Csharp
1 = Fsharp
2 = Java
3 = Php
4 = Python
5 = Kotlin
6 = Swift
7 = Typescript
8 = Javascript
9 = Html
10 = Css
11 = Dart
12 = Rust
13 = Cpp
14 = Golang
15 = Node
16 = Deno
17 = Markdown
18 = Text
19 = Shell
20 = Powershell
21 = Json
22 = Xml
23 = Else
   */
  language?: Language | null;
  /**
   * 0 = Class
1 = Util
2 = Service
3 = Controller
4 = Entity
5 = Model
6 = Config
7 = Interface
8 = Else
   */
  codeType?: CodeType | null;

}
