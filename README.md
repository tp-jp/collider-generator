# ColliderGenerator

�R���C�_�[���w�肵���͈͂ɔz�u�ł���֗��c�[���ł��B
VRChat�̃��[���h�쐬���Ȃǂɂ����p���������B

## �������@

VCC���C���X�g�[���ς݂̏ꍇ�A�ȉ���**�ǂ��炩���**�̎菇���s�����ƂŃC���|�[�g�ł��܂��B

- [VCC Listing](https://tp-jp.github.io/vpm-repos/) �փA�N�Z�X���A�uAdd to VCC�v���N���b�N

- VCC�̃E�B���h�E�� `Setting - Packages - Add Repository` �̏��ɊJ���A `https://tp-jp.github.io/vpm-repos/index.json` ��ǉ�

[VPM CLI](https://vcc.docs.vrchat.com/vpm/cli/) ���g�p���ăC���X�g�[������ꍇ�A�R�}���h���C�����J���ȉ��̃R�}���h����͂��Ă��������B

```
vpm add repo https://tp-jp.github.io/vpm-repos/index.json
```

VCC����C�ӂ̃v���W�F�N�g��I�����A�uManage Project�v����uManage Packages�v���J���܂��B
�ꗗ�̒����� `ColliderGenerator` �̉E�ɂ���u�{�v�{�^�����N���b�N���邩�uInstalled Vection�v����C�ӂ̃o�[�W������I�����邱�ƂŁA�v���W�F�N�g�ɃC���|�[�g���܂��B 

���|�W�g�����g�킸�ɓ����������ꍇ�� [releases](https://github.com/tp-jp/collider-generator/releases) ���� unitypackage ���_�E�����[�h���āA�v���W�F�N�g�ɃC���|�[�g���Ă��������B

## �g����

1. Packages/ColliderGenerator/Runtime/Prefabs/ColliderGenerator.prefab �� Hierarchy �Ƀh���b�O���h���b�v���܂��B

2. Hierarchy��� `ColliderGenerator` ��I�����AInspector ��\�����܂��B

3. Inspector��Őݒ���s���܂��B
   
   - Layout Size X
     �R���C�_�[��z�u����͈́iX�T�C�Y�j�B
   - Layout Size Z
     �R���C�_�[��z�u����͈́iZ�T�C�Y�j�B
   - Layout Count
     �R���C�_�[��z�u���鐔�B
   - Collider Thickness
     �R���C�_�[�̌��݁B
   - Collider Height
     �R���C�_�[�̍����B
   - Collider Edge Length
     �R���C�_�[�̕ӂ̒����B
     0���w�肷��Ǝ����Ōv�Z���܂��B
   - Collider Name Format
     �R���C�_�[�̖��O�̏����B
     �������� `{0}` ���A�Ԃɒu������܂��B

4. Inspector��� `ColliderGenerator` �� `Generate` �{�^�����������邱�Ƃ� `BoxCollider` ����������܂��B
