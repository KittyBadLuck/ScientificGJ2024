- Your characters seems to enter a shop, a good place to get equipment. You realize you do have some money... but not a lot.
‘Well met, weary traveler. You look like you could use some sturdy armor, take a look.’ # merchant
  'It actually looks good !' # you
* [Buy armor] -> armor_buy
* [Steal armor] -> armor_steal

=== armor_buy ===
‘Hehehe, thank you.’ # merchant
‘Wait, it doesn’t look anything like what was shown !’ # you
‘I guess I’ll slay dragons in a metal bikini...’ # you

-> END

=== armor_steal ===
‘Hehehe, if you want it so much, just take it.’
‘What a socialist seller.’ #you
‘Wait, it doesn’t look anything like what was shown !’ # you
‘Hmmm… Why am I the one who feels robbed ?’ #you

-> END