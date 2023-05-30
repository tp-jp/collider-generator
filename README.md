# ColliderGenerator

コライダーを指定した範囲に配置できる便利ツールです。
VRChatのワールド作成時などにご利用ください。

## 導入方法

VCCをインストール済みの場合、以下の**どちらか一つ**の手順を行うことでインポートできます。

- [VCC Listing](https://tp-jp.github.io/vpm-repos/) へアクセスし、「Add to VCC」をクリック

- VCCのウィンドウで `Setting - Packages - Add Repository` の順に開き、 `https://tp-jp.github.io/vpm-repos/index.json` を追加

[VPM CLI](https://vcc.docs.vrchat.com/vpm/cli/) を使用してインストールする場合、コマンドラインを開き以下のコマンドを入力してください。

```
vpm add repo https://tp-jp.github.io/vpm-repos/index.json
```

VCCから任意のプロジェクトを選択し、「Manage Project」から「Manage Packages」を開きます。
一覧の中から `ColliderGenerator` の右にある「＋」ボタンをクリックするか「Installed Vection」から任意のバージョンを選択することで、プロジェクトにインポートします。 
![image](https://github.com/tp-jp/collider-generator/assets/130125691/2a843034-1732-4628-b679-c05a5c5208ad)

リポジトリを使わずに導入したい場合は [releases](https://github.com/tp-jp/collider-generator/releases) から unitypackage をダウンロードして、プロジェクトにインポートしてください。

## 使い方

1. Packages/ColliderGenerator/Runtime/Prefabs/ColliderGenerator.prefab を Hierarchy にドラッグ＆ドロップします。

2. Hierarchy上の `ColliderGenerator` を選択し、Inspector を表示します。

3. Inspector上で設定を行います。
   
   - Layout Size X  
     コライダーを配置する範囲（Xサイズ）。
   - Layout Size Z  
     コライダーを配置する範囲（Zサイズ）。
   - Layout Count  
     コライダーを配置する数。
   - Collider Thickness  
     コライダーの厚み。
   - Collider Height  
     コライダーの高さ。
   - Collider Edge Length  
     コライダーの辺の長さ。  
     0を指定すると自動で計算します。
   - Collider Name Format  
     コライダーの名前の書式。  
     生成時に `{0}` が連番に置換されます。

4. Inspector上で `ColliderGenerator` の `Generate` ボタンを押下することで `BoxCollider` が生成されます。
