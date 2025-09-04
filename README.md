# VamsurLike

## 프로젝트 소개
Unity 개인 개발 프로젝트 연습을 위한 유명 게임 'Vampire Survivors'의 게임 시스템을 모방하여 만든 프로젝트.

## 프로젝트 구현 소개
**수없이 많이 생성되는 오브젝트**  

해당 사항을 효율적으로 메모리 낭비를 적게 하면서 구현하기 위해서
**Object Pooling**을 이용해서 구현하였습니다.

![Image](https://github.com/user-attachments/assets/f2e45319-010c-486f-ac96-fddf7cbacb76)

**캐릭터 선택창 구현 및 업적 달성 시 캐릭터 해금 구현**  

**Playerprefs**를 이용하여 사용자가 업적을 달성하였을 때,
게임을 껏다가 키더라도 해금한 캐릭터가 계속 유지될 수 있도록 구현하였습니다.

![Image](https://github.com/user-attachments/assets/edbf9994-2f4a-4a0f-84ef-b4f8d9d4d545)

**게임 시작 시, 상단 경험치 바, 킬 수, 시간 등 기본 게임 구성 요소 구현**

![Image](https://github.com/user-attachments/assets/b15afe2f-cddd-4f6e-8f9c-9499f929f67b)

**레벨 업 시 선택할 수 있는 업그레이드 선택지 구현**

![Image](https://github.com/user-attachments/assets/9abf07af-f54e-40d4-a65b-7e5121656c19)

**업적 달성 및 몬스터의 시체 구현**  

업적 달성 사운드와 무기 사운드, 발걸음 사운드가 과도하게 겹치는 것을 
방지하기 위해서 **sound channel**을 이용하여 구현하였습니다.

![Image](https://github.com/user-attachments/assets/a4441fbb-bece-4d72-b3e1-f28badd95f9c)

**클리어 화면 및 돌아가기 구현**

