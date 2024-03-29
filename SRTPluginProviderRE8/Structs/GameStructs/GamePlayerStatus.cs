﻿using System.Runtime.InteropServices;

namespace SRTPluginProviderRE8.Structs.GameStructs
{
    [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 0xDD)]

    public struct GamePlayerStatus
    {
        [FieldOffset(0x78)] private bool isEthan;
        [FieldOffset(0x79)] private bool isChris;
        [FieldOffset(0x7A)] private bool isEnableUpdate;
        [FieldOffset(0x7B)] private bool isIdleUpperBody;
        [FieldOffset(0x7C)] private bool isGameOver;
        [FieldOffset(0x7D)] private bool isBlowDamage;
        [FieldOffset(0x7E)] private bool isBlowLand;
        [FieldOffset(0x7F)] private bool isHandsGuard;
        [FieldOffset(0x80)] private bool isMeleeGuard;
        [FieldOffset(0x81)] private bool isGunGuard;
        [FieldOffset(0x82)] private bool isExternalGuard;
        [FieldOffset(0x83)] private bool isFrontForbidAttackTarget;
        [FieldOffset(0x84)] private bool isSlipDamage;
        [FieldOffset(0x85)] private bool isNotifyAcidDamage;
        [FieldOffset(0x86)] private bool isInfiniteBulletByFsmAction;
        [FieldOffset(0x87)] private bool isHideShelf;
        [FieldOffset(0x88)] private bool isHollow;
        [FieldOffset(0x89)] private bool isDisableUpperRotate;
        [FieldOffset(0x90)] private long baseAcionID;
        [FieldOffset(0x98)] private long upperActionID;
        [FieldOffset(0xA0)] private long lArmUpperActionID;
        [FieldOffset(0xA8)] private long eventActionID;
        [FieldOffset(0xB0)] private bool isMeleeAction;
        [FieldOffset(0xB1)] private bool isChrisPunch;
        [FieldOffset(0xB2)] private bool isGunAttack;
        [FieldOffset(0xB3)] private bool isGunAttackLoop;
        [FieldOffset(0xB4)] private bool isEnableChangeFovByAim;
        [FieldOffset(0xB5)] private bool isSprintForbiddenByOrder;
        [FieldOffset(0xB6)] private bool isCrouchForbidden;
        [FieldOffset(0xB7)] private bool isForceDisableProgramMovement;
        [FieldOffset(0xB8)] private bool isAttackForbiddenByOrder;
        [FieldOffset(0xB9)] private bool isGuardForbiddenByOrder;
        [FieldOffset(0xBA)] private bool isUpperBodyActionForbiddenByOrder;
        [FieldOffset(0xBB)] private bool isInputForbiddenByGUI;
        [FieldOffset(0xBC)] private bool isInShop;
        [FieldOffset(0xBD)] private bool isInInventoryMenu;
        [FieldOffset(0xBE)] private bool isInSelectMenu;
        [FieldOffset(0xBF)] private bool isEnableColdBreath;
        [FieldOffset(0xC0)] private bool isInSlipArea;
        [FieldOffset(0xC1)] private bool isInEscapeSlipArea;
        [FieldOffset(0xC2)] private bool isOnBridge;
        [FieldOffset(0xC3)] private bool isOnWaterSurface;
        [FieldOffset(0xC4)] private bool isExecuteThreeGunMatch;
        [FieldOffset(0xC5)] private bool isUseLeftHandWeapon;
        [FieldOffset(0xC6)] private bool isUseLeftHandSequence;
        [FieldOffset(0xC7)] private bool isDisableUseMine;
        [FieldOffset(0xC8)] private bool isFixedAimMode;
        [FieldOffset(0xC9)] private bool isEnableUseLaserIrradiation;
        [FieldOffset(0xD0)] private long playerReference;
        [FieldOffset(0xD8)] private bool isInWaterAreaCam;
        [FieldOffset(0xD9)] private bool isNoReduceBullet;
        [FieldOffset(0xDA)] private bool isLoadingNumDouble;
        [FieldOffset(0xDB)] private bool isForbidReloadCommand;
        [FieldOffset(0xDC)] private bool isForbidAim;

        public bool IsEthan => isEthan;
        public bool IsChris => isChris;
        public bool IsEnableUpdate => isEnableUpdate;
        public bool IsIdleUpperBody => isIdleUpperBody;
        public bool IsGameOver => isGameOver;
        public bool IsBlowDamage => isBlowDamage;
        public bool IsBlowLand => isBlowLand;
        public bool IsHandsGuard => isHandsGuard;
        public bool IsMeleeGuard => isMeleeGuard;
        public bool IsGunGuard => isGunGuard;
        public bool IsExternalGuard => isExternalGuard;
        public bool IsFrontForbidAttackTarget => isFrontForbidAttackTarget;
        public bool IsSlipDamage => isSlipDamage;
        public bool IsNotifyAcidDamage => isNotifyAcidDamage;
        public bool IsInfiniteBulletByFsmAction => isInfiniteBulletByFsmAction;
        public bool IsHideShelf => isHideShelf;
        public bool IsHollow => isHollow;
        public bool IsDisableUpperRotate => isDisableUpperRotate;
        public long BaseAcionID => baseAcionID;
        public long UpperActionID => upperActionID;
        public long LArmUpperActionID => lArmUpperActionID;
        public long EventActionID => eventActionID;
        public bool IsMeleeAction => isMeleeAction;
        public bool IsChrisPunch => isChrisPunch;
        public bool IsGunAttack => isGunAttack;
        public bool IsGunAttackLoop => isGunAttackLoop;
        public bool IsEnableChangeFovByAim => isEnableChangeFovByAim;
        public bool IsSprintForbiddenByOrder => isSprintForbiddenByOrder;
        public bool IsCrouchForbidden => isCrouchForbidden;
        public bool IsForceDisableProgramMovement => isForceDisableProgramMovement;
        public bool IsAttackForbiddenByOrder => isAttackForbiddenByOrder;
        public bool IsGuardForbiddenByOrder => isGuardForbiddenByOrder;
        public bool IsUpperBodyActionForbiddenByOrder => isUpperBodyActionForbiddenByOrder;
        public bool IsInputForbiddenByGUI => isInputForbiddenByGUI;
        public bool IsInShop => isInShop;
        public bool IsInInventoryMenu => isInInventoryMenu;
        public bool IsInSelectMenu => isInSelectMenu;
        public bool IsEnableColdBreath => isEnableColdBreath;
        public bool IsInSlipArea => isInSlipArea;
        public bool IsInEscapeSlipArea => isInEscapeSlipArea;
        public bool IsOnBridge => isOnBridge;
        public bool IsOnWaterSurface => isOnWaterSurface;
        public bool IsExecuteThreeGunMatch => isExecuteThreeGunMatch;
        public bool IsUseLeftHandWeapon => isUseLeftHandWeapon;
        public bool IsUseLeftHandSequence => isUseLeftHandSequence;
        public bool IsDisableUseMine => isDisableUseMine;
        public bool IsFixedAimMode => isFixedAimMode;
        public bool IsEnableUseLaserIrradiation => isEnableUseLaserIrradiation;
        public long PlayerReference => playerReference;
        public bool IsInWaterAreaCam => isInWaterAreaCam;
        public bool IsNoReduceBullet => isNoReduceBullet;
        public bool IsLoadingNumDouble => isLoadingNumDouble;
        public bool IsForbidReloadCommand => isForbidReloadCommand;
        public bool IsForbidAim => isForbidAim;
    }
}