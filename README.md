# Speed Drop

Unityで制作しているゲームプロジェクトです。.

## 基本ルール

* `main`では基本作業しない
* 作業ごとにブランチを作る  
* 作業後はコミット・プッシュする
* Pull Requestを作り、確認後に`main`へマージする
* タスク管理はGitHub ProjectsのKanbanを使う

## フォルダ

```text
Assets/_Project
├─ Scripts
├─ Prefabs
├─ Scenes
├─ Art
├─ Audio
└─ Settings
```

* スクリプトは`Scripts`に入れる
* Prefabは`Prefabs`に入れる
* シーンは`Scenes`に入れる
* 画像や3D素材は`Art`に入れる
* BGMや効果音は`Audio`に入れる

必要なフォルダがなければ随時追加してください。

## Prefab

よく使うオブジェクトはPrefabにします。

例：

* Player
* 障害物
* ステージ
* UI
* エフェクト

Prefabにしておけば、必要なときにシーンへドラッグするだけで使えます。

## 作業の流れ

```text
mainをPull
↓
作業ブランチを作成
↓
Unityで作業・保存
↓
コミット
↓
プッシュ
↓
Pull Request
↓
mainへマージ
```

## 注意

* 同じシーンを複数人で同時に編集しない
* `.meta`ファイルを消さない
* 分からない競合は勝手に解決しない
* エラーがある状態でmainへマージしない
* 困ったらプロジェクトのChatGPTかCODEXに聞いてみる

## Unityの画面

![Unityの画面](docs/images/unity-screen.png)