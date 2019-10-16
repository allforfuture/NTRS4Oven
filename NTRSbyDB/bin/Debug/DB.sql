SELECT AVG(CAST(inspect_text AS FLOAT)),
CASE
 WHEN AVG(CAST(inspect_text AS FLOAT)) <= '3.68' THEN 'BinA'
 WHEN AVG(CAST(inspect_text AS FLOAT)) > '3.68' AND AVG(CAST(inspect_text AS FLOAT)) <= '3.70' THEN 'BinB'
 ELSE 'BinC'
END
FROM
 (SELECT a.serial_cd,c.inspect_cd,c.inspect_text,
 RANK() OVER (PARTITION BY a.serial_cd,c.inspect_cd ORDER BY c.process_at DESC)
 FROM t_insp_kk09 AS a
 JOIN m_process AS b on a.proc_uuid = b.proc_uuid
 JOIN t_data_kk09 AS c ON a.insp_seq = c.insp_seq
 WHERE b.process_cd = 'AE-61'
 AND c.inspect_cd IN ('L-FRAME_HT_FAI-1-P1','L-FRAME_HT_FAI-1-P2','L-FRAME_HT_FAI-1-P3','L-FRAME_HT_FAI-1-P4','L-FRAME_HT_FAI-1-P5','L-FRAME_HT_FAI-1-P6',
                      'L-FRAME_HT_FAI-1-P7','L-FRAME_HT_FAI-1-P8','L-FRAME_HT_FAI-1-P9','L-FRAME_HT_FAI-1-P10','L-FRAME_HT_FAI-1-P11','L-FRAME_HT_FAI-1-P12',
                      'L-FRAME_HT_FAI-1-P13','L-FRAME_HT_FAI-1-P14','L-FRAME_HT_FAI-1-P15')
 AND a.serial_cd = '{0}'
 ) AS m
WHERE RANK = '1'
GROUP BY serial_cd