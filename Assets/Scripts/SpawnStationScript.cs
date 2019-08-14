using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStationScript : MonoBehaviour
{
    // A list with all available wave files.
    [SerializeField] List<WaveControllerScript> field_waveControllerScript_waves;
    private int field_int_waveIndex = 0;

    // A variable that controls if all waves should be looped or not.
    private bool field_bool_loopAllWaves = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnEveryWave());
        } while (field_bool_loopAllWaves);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Spawning enemies with the get method getHowManyEnemies().
     * Using a coroutine that waits a given number of seconds, getSpawnInterval(), before executing again.
     * Quaternion.identity basically means just use the starting rotation, nothing being manipulated. 
     */

    private IEnumerator SpawnEntireWave(WaveControllerScript p_waveControllerScript)
    {
        for (int i = 0; i < p_waveControllerScript.getHowManyEnemies(); i++)
        {
            var local_spawnNewEnemy = Instantiate(p_waveControllerScript.GetEnemy(), p_waveControllerScript.getAllPassages()[0].transform.position, Quaternion.identity);
            local_spawnNewEnemy.GetComponent<EnemyPathway>().SetWaveController(p_waveControllerScript);
            yield return new WaitForSeconds(p_waveControllerScript.getSpawnInterval());
        }
    }

    /*
     * A function that goes through the entire list of wave files. The coroutine will make sure that an entire wave have to end first before the next wave begins.
     */ 

    private IEnumerator SpawnEveryWave()
    {
        for (int i = field_int_waveIndex; i < field_waveControllerScript_waves.Count; i++)
        {
            var local_wave = field_waveControllerScript_waves[i];
            yield return StartCoroutine(SpawnEntireWave(local_wave));
        }
    }
}
