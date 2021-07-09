using UnityEngine;
using Zenject;
using sakuGame;
using sakuGame.InputSystem;
using sakuGame.BGM;
using sakuGame.Guzai;
public class UntitledInstaller : MonoInstaller 
{
    [SerializeField]
    GameObject InputObj;
    [SerializeField]
    GameObject TempoObj;
    [SerializeField]
    GameObject CanslashObj;
    public override void InstallBindings()
    {
        //.AsSingle�@�V���O���g���̂�����
        //ASCached �C���X�^���X���ɂ���΍ė��p
        //Astranslate ���̂��тɐ���
        //Container.Bind<sakuGame.Guzai.IJudgeEndTime>()
        //    .To<sakuGame.Guzai.CanSlashJudge>()

        //    //.FromComponentsOn(obj)
        //    .AsCached();
        Container.Bind<IInputer>()
            .To<Inputer>()
            .FromComponentOn(InputObj)
            .AsCached();

        Container.Bind<IWhen_RhythmTiming>()
            .To<TempoGenerator>()
            .FromComponentOn(TempoObj)
            .AsCached();
        Container.Bind<IWhen_SlowTiming>()
            .To<TempoGenerator>()
            .FromComponentOn(TempoObj)
            .AsCached();
        Container.Bind<IWhenEndBgm>()
           .To<TempoGenerator>()
           .FromComponentOn(TempoObj)
           .AsCached();

        Container.Bind<IJudgeEndTime>()
            .To<CanSlashJudge>()
            .FromComponentOn(CanslashObj)
            .AsCached();
        Container.Bind<IGuzaiSlash>()
            .To<CanSlashJudge>()
            .FromComponentOn(CanslashObj)
            .AsTransient();
        
    }
}